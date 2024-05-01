import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { DangTinComponent } from './home/dang-tin/dang-tin.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: '',
   // component: HomeComponent,
    runGuardsAndResolvers: 'always',
    canActivate:[AuthGuard],
    children:[
      {
        path: 'dang-tin',
        component: DangTinComponent,
      },
      {
        path: 'tin-tuc',
        component: DangTinComponent,
      },
    ]
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'admin',
    component: AdminComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
