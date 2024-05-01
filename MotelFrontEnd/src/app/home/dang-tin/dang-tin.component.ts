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
  file: any = [];
  constructor(private motelService: MotelService, private router: Router) {

  }
  ngOnInit(): void {
    // this.model.images = [];
  }

  dangTin() {
    this.model.images = this.file;
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
      console.log(reader.result);
      // const file = reader.result;

      this.file = {
        name: file?.name,
        base64: reader.result?.toString().split(',')[1] as string,
        type: url,
      }
    };
  }
}
export interface SelectedFiles {
  name: string
  base64?: string
  type?: string
}
