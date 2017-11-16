import { Component, OnInit, Output, EventEmitter, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
    selector: 'paging',
    templateUrl: 'paging.component.html',
    styleUrls: ['./paging.component.css']
})

export class PagingComponent implements OnInit, OnChanges {


    @Input() totalItems : number;
    @Input() itemsPerPage : number;

    @Output() pageChanged = new EventEmitter();

    currentPage = 1;
    pages : number[] = [];

    constructor() { }

    ngOnInit() {

    }
    ngOnChanges(changes: SimpleChanges): void {
        let totalPages = Math.ceil(this.totalItems / this.itemsPerPage);       
        this.pages = [];
        for(let i = 1; i <= totalPages; i++)
        {
            this.pages.push(i);
        }
    }

    changePage(page : number)
    {
        this.currentPage = page;
        this.pageChanged.emit(page);
    }
    onPageClick(page : number)
    {
        this.changePage(page);
    }

    onPrevClicked()
    {
        if(this.currentPage == 1)
        {
            return;
        }

        this.changePage(this.currentPage - 1);
    }

    onNextClicked()
    {
        if(this.currentPage == this.pages.length)
        {
            return;
        }

        this.changePage(this.currentPage + 1);      
    }
}