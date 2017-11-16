import { Component, OnInit, Output, EventEmitter } from '@angular/core';


enum LengthOptions
{
  ANY = 1,
  SHORT = 2,
  MEDIUM = 3,
  LONG = 4,
  SPECIFIC = 5
}

@Component({
  selector: 'video-length-filter',
  templateUrl: './video-length-filter.component.html',
  styleUrls: ['./video-length-filter.component.css']
})
export class VideoLengthFilterComponent implements OnInit {

  constructor() { }

  @Output() lengthChanged = new EventEmitter();
  selectedOption = LengthOptions.ANY;
  range = [0, 60];
  minLengthDisplayValue = "";
  maxLengthDisplayValue = "";

  ngOnInit() {
    this.updateDisplayValues();
  }

  onLengthChanged(event : any, option : number)
  {
    event.preventDefault();
    
    let lengthEvent = {
      maxLength : 0,
      minLength : 0
    };

    if(event.target.attributes.maxLength)
      lengthEvent.maxLength = event.target.attributes.maxLength.nodeValue;

    if(event.target.attributes.minLength)
      lengthEvent.minLength = event.target.attributes.minLength.nodeValue;

    this.lengthChanged.emit(lengthEvent);
    this.selectedOption = option;
  }

  onSpecificLengthClicked()
  {
    this.selectedOption = LengthOptions.SPECIFIC;
  }

  secondsToTime(seconds : number)
  {
    var h = Math.floor(seconds / 3600);
    var m = Math.floor(seconds % 3600 / 60);
    var s = Math.floor(seconds % 3600 % 60); 
    
    return ('0' + h).slice(-2) + ":" + ('0' + m).slice(-2) + ":" + ('0' + s).slice(-2);
  }

  updateDisplayValues()
  {
    var minLength = this.range[0]*60;
    var maxLength = this.range[1]*60;
    this.minLengthDisplayValue = this.secondsToTime(minLength);
    this.maxLengthDisplayValue = this.secondsToTime(maxLength);
  }
  specificRangeChanged(event: any)
  {
    this.updateDisplayValues();

  }
}
