import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AccountComponent } from './account.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: '',
        component: AccountComponent,
        children: [
          {
            path: '', component: LoginComponent
          }
        ]
      }
    ])
  ],
  exports: [
    RouterModule
  ]
})

export class AccountRoutingModule { }
