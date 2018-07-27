import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

/**
 * 初始化路由
 */
const routes: Routes = [
  {
    path: '',
    loadChildren: './main/main.module#MainModule'
  },
  {
    path: 'account',
    loadChildren: './account/account.module#AccountModule'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], // 路由配置
  exports: [RouterModule] // 一定要记得这个导出，不然会报错，
})

export class AppRoutingModule { }
