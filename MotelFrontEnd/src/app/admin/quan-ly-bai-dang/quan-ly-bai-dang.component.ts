import { Component, OnInit } from '@angular/core';
import { MotelService } from '../../service/motel.service';
import { TableModule } from 'primeng/table';
@Component({
  selector: 'app-quan-ly-bai-dang',
  templateUrl: './quan-ly-bai-dang.component.html',
  styleUrl: './quan-ly-bai-dang.component.css',

})
export class QuanLyBaiDangComponent implements OnInit {
  motelResponses:any;
  constructor(private motelService: MotelService) {
  }
  ngOnInit(): void {
    this.motelService.getMotel().subscribe(res=>{
      this.motelResponses = res.data;
    });
  }
}
