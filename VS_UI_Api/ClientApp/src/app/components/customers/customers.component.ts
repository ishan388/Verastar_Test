import { Component, OnInit } from '@angular/core';
import * as XLSX from 'xlsx';
import { Customer } from '../../models/customer.model';
import { CustomersService } from '../../services/customers.service';
const { read, write, utils } = XLSX;

@Component({
  selector: 'customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  public uploadedCustomerData: any;
  public allCustomers: Customer[] = [];
  constructor(private service: CustomersService) { }

  ngOnInit(): void {
    this.getAllCustomers();
  }

  onFileChange(evt: any) {
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
      this.uploadedCustomerData = (XLSX.utils.sheet_to_json(ws, { header: 1 }));
    }
    evt.target.value = null;
  }

  saveImportedCustomers() {

    this.uploadedCustomerData.splice(0, 1);
    this.uploadedCustomerData = this.uploadedCustomerData.filter((e: string[]) => !this.allCustomers.find(c => c.email.toLowerCase() == e[4].toLowerCase()));
    let data: Customer[] = [];
    for (let i = 0; i < this.uploadedCustomerData.length; i++) {
      data.push(new Customer(
        this.uploadedCustomerData[i][1] as string,
        this.uploadedCustomerData[i][2] as string,
        this.uploadedCustomerData[i][4] as string,
        this.uploadedCustomerData[i][3] as string,
        this.uploadedCustomerData[i][5] as string,
        this.uploadedCustomerData[i][6] as string,
        this.uploadedCustomerData[i][7] as string,
        this.uploadedCustomerData[i][8] as string,
      ));
    }
    this.service.saveImportedCustomers(data).subscribe(res => {
      this.getAllCustomers();
    });
  }

  getAllCustomers() {
    this.cancel();
    this.service.getAllCustomers().subscribe(res => {
      this.allCustomers = res.dataList;
    });
  }

  cancel() {
    this.uploadedCustomerData = null;
  }

}
