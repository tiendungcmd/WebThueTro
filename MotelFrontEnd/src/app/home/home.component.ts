import { Component, OnInit } from '@angular/core';
import { CarouselModule } from 'primeng/carousel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  images: silde[] = [];
  ngOnInit(): void {
    this.images = [{
      imgSrc:'assets/image1.jpg',
      imgAlt:'image 1'
    },
    {
      imgSrc:'assets/image2.jpg',
      imgAlt:'image 2'
    },
    {
      imgSrc:'assets/image3.jpg',
      imgAlt:'image 3'
    }]
  }
}
interface silde {
  imgSrc: string,
  imgAlt: string
}
