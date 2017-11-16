import { Component, OnInit, OnChanges, SimpleChanges, Input } from '@angular/core';

@Component({
  selector: 'description',
  templateUrl: './description.component.html',
  styleUrls: ['./description.component.css']
})
export class DescriptionComponent implements OnInit, OnChanges {


  @Input() text : string;
  displayText : string;
  hidden  = true;
  linkLabel = "show"
  visibleCharactersCount = 300;
  trail = "...";
  constructor() { }

  ngOnInit() {

    this.displayText = this.text;
    this.linkLabel = this.hidden ? "show" : "hide";
  }

  hideFullText()
  {
    this.displayText = this.text.length > this.visibleCharactersCount ?
    this.text.substring(0, this.visibleCharactersCount).trim() + this.trail
     : this.text;
  }

  showFullText()
  {
    this.displayText = this.text;
  }

  updateText()
  {
    if(this.hidden)
      this.hideFullText();
    else
      this.showFullText();
  }


  ngOnChanges(changes: SimpleChanges): void {

    if(changes.text)
    {
      this.updateText();
    }
  }

  toggle()
  {
    this.hidden = !this.hidden;
    this.linkLabel = this.hidden ? "show" : "hide";
    this.updateText();
  }

}
