/**
 * 拓展插件
 * MJZ
 * 2016年12月29日17:26:55
 */
(function ($) {
    //图片自适应屏幕大小插件
    $.fn.imgAutoAdaScreenSize = function (options) {
        var element = $(this); //获取当前元素
        //默认参数配置
        var defalutOptions = {
            isForceStretch: false //是否强制拉长到屏幕高度一样高
        };
        /*合并参数*/
        $.extend(true, defalutOptions, options);
        console.info(defalutOptions.isForceStretch);
        //加载图片的大小
        var loadImgSize = function () {
            //参数范围获取
            var realWidth;
            var realHeight;
            var windowsHeight = $(window).height();
            var windowsWidth = $(window).width();
            /*
            如果要获取图片的真实的宽度和高度有三点必须注意
            1、需要创建一个image对象：如这里的$("<img/>")
            2、指定图片的src路径
            3、一定要在图片加载完成后执行如.load()函数里执行
            */

            $("<img/>").attr("src", element.attr("src")).load(function () {
                //获取原始图片的高度
                realWidth = this.width;
                realHeight = this.height;

                //调试部分
                console.info("屏幕的高度：" + windowsHeight);
                console.info("图片的真实高度：" + realHeight);
                console.info("图片的真实宽度：" + realWidth);
                //遍历元素
                element.each(function (i, item) {
                    //定义样式
                    var style = {
                        "max-width": "100%",
                        "display": "block"
                    };
                    //如果有自定义的样式直接添加style属性即可
                    if (defalutOptions.style) {
                        $.extend(true, style, options.style);
                    }
                    //是否强制将图片时长屏幕的文档高度
                    if (!defalutOptions || !defalutOptions.isForceStretch) {
                        element.AutoResizeImage(windowsWidth, 0);
                    } else {
                        //强制要求屏幕的高度
                        style.height = windowsHeight;
                        style.width = windowsWidth;
                    }
                    //添加样式
                    $(item).css(style);
                });
            });
        }

        loadImgSize();
    }

    //元素自定定位插件 @param {} options 参数对象:{};callBack 回调函数
    $.fn.AutoPosition = function (options, callBack) {
        var element = $(this); //获取当前元素
        //默认参数配置
        var defalutOptions = {

        };
        /*合并参数*/
        $.extend(true, defalutOptions, options);
        //遍历元素
        $(element).each(function (i, item) {
            //获取范围对象
            var range = defalutOptions.range;
            var btnRealWidth = ((range.btnWidth / range.btnBaseWidth) * 100) + "%";
            var btnRealHeight = ((range.btnHeight / range.btnBaseHeight) * 100) + "%";
            var btnRealTop = ((range.btnTop / range.btnBaseHeight) * 100) + "%";
            var btnRealLeft = ((range.btnLeft / range.btnBaseWidth) * 100) + "%";
            //添加动态参数（定位使用）
            defalutOptions.style["width"] = btnRealWidth;
            defalutOptions.style["z-index"] = 99;
            defalutOptions.style["height"] = btnRealHeight;
            defalutOptions.style["position"] = "absolute";
            defalutOptions.style["top"] = btnRealTop;
            defalutOptions.style["left"] = btnRealLeft;
            //添加样式
            $(item)
                .css(defalutOptions.style)
                .parent()
                .css({
                    "position": "relative"
                });
        });
        //执行回调函数
        if (callBack && typeof callBack === "function") {
            callBack();
        }
    }

    //根据设定的高宽来自动压缩图片
    $.fn.AutoResizeImage = function (maxWidth, maxHeight) {
        var img = new Image();
        img.src = $(this).attr("src");
        var Ratio = 1;
        var w = img.width;
        var h = img.height;
        var wRatio = maxWidth / w;
        var hRatio = maxHeight / h;
        if (maxWidth === 0 && maxHeight === 0) {
            Ratio = 1;
        } else if (maxWidth === 0) {//  
            if (hRatio < 1) Ratio = hRatio;
        } else if (maxHeight === 0) {
            if (wRatio < 1) Ratio = wRatio;
        } else if (wRatio < 1 || hRatio < 1) {
            Ratio = (wRatio <= hRatio ? wRatio : hRatio);
        }
        if (Ratio < 1) {
            w = w * Ratio;
            h = h * Ratio;
        }
        $(this).height = h;
        $(this).width = w;
    }

})(jQuery);