import { Observable } from 'rxjs';
import * as XLSX from 'xlsx';
const { read, write, utils } = XLSX;

export class XLSXService {

  public importExcelData(evt: any) {
    debugger;
    let data: any[] = [];
    const target: DataTransfer = <DataTransfer>(evt.target);
    if (target.files.length !== 1) throw new Error('Cannot use multiple files');
    const reader: FileReader = new FileReader();
    reader.readAsBinaryString(target.files[0]);
    reader.onload = (e: any) => {
      /* read workbook */
      const bstr: string = e.target.result;
      const wb: XLSX.WorkBook = XLSX.read(bstr, { type: 'binary' });

      /* grab first sheet */
      const wsname: string = wb.SheetNames[0];
      const ws: XLSX.WorkSheet = wb.Sheets[wsname];

      /* fill data */
      data = (XLSX.utils.sheet_to_json(ws, { header: 1 }));
      console.log(data);
    }
    return new Promise(resolve => { resolve(data) });
  }

}
