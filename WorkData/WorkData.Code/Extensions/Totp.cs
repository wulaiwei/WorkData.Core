// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：Totp.cs
// 创建标识：吴来伟 2018-01-31 13:53
// 创建描述：
//
// 修改标识：吴来伟2018-01-31 13:53
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace WorkData.Code.Extensions
{
    /// <summary>
    ///     https://tools.ietf.org/html/rfc6238
    /// </summary>
    public static class Totp
    {
        private static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static TimeSpan _timestep = TimeSpan.FromSeconds(30);
        private static readonly Encoding _encoding = new UTF8Encoding(false, true);

        private static int ComputeTotp(HashAlgorithm hashAlgorithm, ulong timestepNumber, string modifier)
        {
            // # of 0's = length of pin
            const int Mod = 1000000;
            // See https://tools.ietf.org/html/rfc4226
            // We can add an optional modifier
            var timestepAsBytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((long)timestepNumber));

            var hash = hashAlgorithm.ComputeHash(ApplyModifier(timestepAsBytes, modifier));

            // Generate DT string
            var offset = hash[hash.Length - 1] & 0xf;

            var binaryCode = (hash[offset] & 0x7f) << 24
                             | (hash[offset + 1] & 0xff) << 16
                             | (hash[offset + 2] & 0xff) << 8
                             | (hash[offset + 3] & 0xff);

            return binaryCode % Mod;
        }

        private static byte[] ApplyModifier(byte[] input, string modifier)
        {
            if (string.IsNullOrEmpty(modifier))
            {
                return input;
            }

            var modifierBytes = _encoding.GetBytes(modifier);
            var combined = new byte[checked(input.Length + modifierBytes.Length)];
            Buffer.BlockCopy(input, 0, combined, 0, input.Length);
            Buffer.BlockCopy(modifierBytes, 0, combined, input.Length, modifierBytes.Length);
            return combined;
        }

        // More info: https://tools.ietf.org/html/rfc6238#section-4
        private static ulong GetCurrentTimeStepNumber()
        {
            var delta = DateTime.UtcNow - _unixEpoch;
            return (ulong)(delta.Ticks / _timestep.Ticks);
        }

        /// <summary>
        ///     Generates code for the specified <paramref name="securityToken" />.
        /// </summary>
        /// <param name="securityToken">The security token to generate code.</param>
        /// <param name="modifier">The modifier.</param>
        /// <returns>The generated code.</returns>
        public static int GenerateCode(byte[] securityToken, string modifier = null)
        {
            if (securityToken == null)
            {
                throw new ArgumentNullException(nameof(securityToken));
            }

            // Allow a variance of no greater than 90 seconds in either direction
            var currentTimeStep = GetCurrentTimeStepNumber();
            using (var hashAlgorithm = new HMACSHA1(securityToken))
            {
                var info = ComputeTotp(hashAlgorithm, currentTimeStep, modifier);
                return info;
            }
        }

        /// <summary>
        ///     Validates the code for the specified <paramref name="securityToken" />.
        /// </summary>
        /// <param name="securityToken">The security token for verifying.</param>
        /// <param name="code">The code to validate.</param>
        /// <param name="modifier">The modifier</param>
        /// <returns><c>True</c> if validate succeed, otherwise, <c>false</c>.</returns>
        public static bool ValidateCode(byte[] securityToken, int code, string modifier = null)
        {
            if (securityToken == null)
            {
                throw new ArgumentNullException(nameof(securityToken));
            }

            // Allow a variance of no greater than 90 seconds in either direction
            var currentTimeStep = GetCurrentTimeStepNumber();
            using (var hashAlgorithm = new HMACSHA1(securityToken))
            {
                for (var i = -2; i <= 2; i++)
                {
                    var computedTotp = ComputeTotp(hashAlgorithm, (ulong)((long)currentTimeStep + i), modifier);
                    if (computedTotp == code)
                    {
                        return true;
                    }
                }
            }

            // No match
            return false;
        }

        /// <summary>
        ///     Generates code for the specified <paramref name="securityToken" />.
        /// </summary>
        /// <param name="securityToken">The security token to generate code.</param>
        /// <param name="modifier">The modifier.</param>
        /// <returns>The generated code.</returns>
        public static int GenerateCode(string securityToken, string modifier = null) => GenerateCode(
            Encoding.Unicode.GetBytes(securityToken), modifier);

        /// <summary>
        ///     Validates the code for the specified <paramref name="securityToken" />.
        /// </summary>
        /// <param name="securityToken">The security token for verifying.</param>
        /// <param name="code">The code to validate.</param>
        /// <param name="modifier">The modifier</param>
        /// <returns><c>True</c> if validate succeed, otherwise, <c>false</c>.</returns>
        public static bool ValidateCode(string securityToken, int code, string modifier = null) => ValidateCode(
            Encoding.Unicode.GetBytes(securityToken), code, modifier);
    }
}