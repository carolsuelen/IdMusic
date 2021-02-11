import { Component, OnInit } from '@angular/core';
import $ from "jquery";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    $(document).ready(function(){
      var teste = $('#fadeTeste');
      $('#fadeTeste').fadeIn(4000);
      console.log('teste');
      console.log(teste);
    });
  }

}
