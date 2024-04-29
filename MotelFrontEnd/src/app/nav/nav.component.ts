import { Component } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  model: any = {};
  currentUser$: any;
  constructor(){}
  ngOnInit(): void {
  }

  login(){
    // this.accountService.login(this.model).subscribe({
    //   next: _ => this.router.navigateByUrl('/members'),
    //   error: error => this.toastr.error(error.error)
    // });
  }

  logout(){
    // this.accountService.logout();
    // this.router.navigateByUrl('/')
  }
}
