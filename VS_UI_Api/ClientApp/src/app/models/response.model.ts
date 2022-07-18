export class Response<T> {
  data!: T;
  dataList!: T[];
  message: string = '';
  isSuccess: boolean = false;
}
