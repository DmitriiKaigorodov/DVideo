import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'title'
})

export class TitlePipe implements PipeTransform {
    transform(value: string, ...args: any[]): any {

        let limit = args.length > 0 ? parseInt(args[0], 10) : 10;
        let trail = args.length > 1 ? args[1] : '...';
    
        return value.length > limit ? value.substring(0, limit) + trail : value;
    }
}