import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import {AddExpenseComponent} from './components/add-expense/add-expense.component';
const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path:'auth',
    loadChildren: () => import('./auth/auth.module').then(m => m.default)
  },
  {
    path:'commons',
    loadChildren: () => import('./common/common.module').then(m => m.default)
  },
  {
    path:'exp',
    component: AddExpenseComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }