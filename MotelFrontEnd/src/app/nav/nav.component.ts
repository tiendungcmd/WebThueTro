import { Component } from '@angular/core';
import { AccountService } from '../service/account.service';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { User } from '../model/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  model: any = {};
  currentUser$: Observable<User | null>  = of(null);
  constructor(private accountService: AccountService, private router: Router) { }
  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
  }

  login() {
    var x = this.accountService.login(this.model).subscribe({
      next:(value:any)=> {
          console.log(value)
      },
    })
    console.log(x);
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/')
  }
}
