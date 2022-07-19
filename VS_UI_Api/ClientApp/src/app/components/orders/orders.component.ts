import { Component, OnInit } from '@angular/core';
import * as XLSX from 'xlsx';
import { Order } from '../../models/order.model';
import { OrdersService } from '../../services/orders.service';
const { read, write, utils } = XLSX;

@Component({
  selector: 'orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  public uploadedOrderData: any;
  public allOrders: Order[] = [];

  constructor(private service: OrdersService) { }

  ngOnInit(): void {
    this.getAllOrders();
  }

  getAllOrders() {
    this.cancel();
    this.service.getAllOrders().subscribe(res => {
      this.allOrders = res.dataList;
    });
  }
  cancel() {
    this.uploadedOrderData = null;
  }

  saveImportedOrders() {
    this.uploadedOrderData.splice(0, 1);
    this.uploadedOrderData = this.uploadedOrderData.filter((e: string[]) => !this.allOrders.find(o => o.id.toString() == e[0]));
    let data: Order[] = [];
    for (let i = 0; i < this.uploadedOrderData.length; i++) {
      if (this.uploadedOrderData[i][0] as number > 0) {
        data.push(new Order(
          this.uploadedOrderData[i][0] as number,
          this.uploadedOrderData[i][1] as number,
          this.uploadedOrderData[i][2] as number,
          this.uploadedOrderData[i][3] as string,
          this.uploadedOrderData[i][4] as string,
          this.uploadedOrderData[i][5] as string
        ));
      }
    }
    this.service.saveImportedOrders(data).subscribe(res => {
      this.getAllOrders();
    });
  }

  onFileChange(evt: any) {
    const target: DataTransfer = <DataTransfer>(evt.target);
    if (target.files.length !== 1) throw new Error('Cannot use multiple files');
    const reader: FileReader = new FileReader();
    reader.readAsBinaryString(target.files[0]);
    reader.onload = (e: any) => {
      /* read workbook */
      const bstr: string = e.target.result;
      const wb: XLSX.WorkBook = XLSX.read(bstr, { type: 'binary', cellText: false, cellDates: true });

      /* grab first sheet */
      const wsname: string = wb.SheetNames[0];
      const ws: XLSX.WorkSheet = wb.Sheets[wsname];

      /* fill data */
      this.uploadedOrderData = (XLSX.utils.sheet_to_json(ws, { header: 1, raw: false, dateNF: 'dd/MM/yyyy' }));
    }
    evt.target.value = null;
  }

}
