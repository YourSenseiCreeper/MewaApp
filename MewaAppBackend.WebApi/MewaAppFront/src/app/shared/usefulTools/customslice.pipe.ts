import {Pipe, PipeTransform} from "@angular/core";

@Pipe({
  name: 'customSlice'
})
export class CustomslicePipe implements PipeTransform {
  transform(val: string, lenght: number): string {
    return (val.length>length)? val.slice(0, lenght)+'...':val;
  }
}
