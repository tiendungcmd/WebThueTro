import { Component, OnInit } from '@angular/core';
import { MotelService } from '../../service/motel.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dang-tin',
  templateUrl: './dang-tin.component.html',
  styleUrl: './dang-tin.component.css'
})
export class DangTinComponent implements OnInit {
  model: any = {};
  file: any;
  constructor(private motelService: MotelService, private router: Router) {

  }
  ngOnInit(): void {
    // this.model.images = [];
  }

  dangTin() {
    this.model.images = this.file.File;
    this.model.status = 2;
    this.motelService.dangTin(this.model).subscribe(res => {
      console.log(res.data)
      if(res.success){
        this.router.navigateByUrl('/')
      }
    })
  }

  handleUpload(event: any) {
    const file = event.target.files[0];
    const url = URL.createObjectURL(file)
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      // const file = reader.result;

      this.file = {
        Name: file?.name,
        File: file,
        Type: url,
      }
    };
  }
}
export interface SelectedFiles {
  name: string
  base64?: string
  type?: string
}
