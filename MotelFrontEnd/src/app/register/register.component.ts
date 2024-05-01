import { Component } from '@angular/core';
import { AccountService } from '../service/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
 // @Output() cancelRegister = new EventEmitter();
  model: any = {}

  constructor(private accountService: AccountService,
    private toastr: ToastrService){}
  ngOnInit() : void{

  }

  register(){
    this.accountService.register(this.model).subscribe(res=>{
      localStorage.setItem('user', JSON.stringify(res.userName));
    })
  }

  cancel(){
  }
}
