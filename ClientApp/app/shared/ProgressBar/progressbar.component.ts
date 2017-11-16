import { Component, OnInit, Input, SimpleChanges } from '@angular/core';

@Component({
    selector: 'progress-bar',
    templateUrl: 'progressbar.component.html'
})
export class ProgressBarComponent implements OnInit {

    @Input() progress : Number = 0;
    constructor() { }

    ngOnInit() { }

    ngOnChange(changed : SimpleChanges)
    {
        
    }
}