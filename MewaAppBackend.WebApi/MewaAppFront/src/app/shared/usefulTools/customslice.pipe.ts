import {Pipe, PipeTransform} from "@angular/core";

@Pipe({
  name: 'customSlice'
})
export class CustomslicePipe implements PipeTransform {
  transform(val: string | null, lenght: number): string {
    if (!val)
      return '';
    return (val.length>length)? val.slice(0, lenght)+'...':val;
  }
}
