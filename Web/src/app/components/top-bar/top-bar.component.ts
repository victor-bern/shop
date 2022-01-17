import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.scss'],
})
export class TopBarComponent implements OnInit {
  isHome: boolean = false;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    if (this.route.component?.toString().startsWith('class Home'))
      this.isHome = true;
    console.log(this.isHome);
  }
}
