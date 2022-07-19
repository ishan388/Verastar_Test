import { Component, OnInit } from '@angular/core';
import * as XLSX from 'xlsx';
import { OrderItem, } from '../../models/order-item.model';
import { OrderItemsService } from '../../services/order-items.service';

@Component({
  selector: 'order-items',
  templateUrl: './order-items.component.html',
  styleUrls: ['./order-items.component.css']
})
export class OrderItemsComponent implements OnInit {

  public uploadedOrderItemData: any;
  public allOrderItems: OrderItem[] = [];
  constructor(private service: OrderItemsService) { }

  ngOnInit(): void {
    this.getAllOrderItems();
  }

  getAllOrderItems() {
    this.cancel();
    this.service.getAllOrderItems().subscribe(res => {
      this.allOrderItems = res.dataList;
    });
  }
  cancel() {
    this.uploadedOrderItemData = null;
  }

  saveImportedOrderItems() {
    this.uploadedOrderItemData.splice(0, 1);
    this.uploadedOrderItemData = this.uploadedOrderItemData.filter((e: string[]) =>
      !this.allOrderItems.find(o => o.orderId.toString() == e[0] && o.itemId.toString() == e[1]));
    let data: OrderItem[] = [];
    for (let i = 0; i < this.uploadedOrderItemData.length; i++) {
      if (this.uploadedOrderItemData[i][0] as number > 0) {
        data.push(new OrderItem(
          this.uploadedOrderItemData[i][0] as number,
          this.uploadedOrderItemData[i][1] as number,
          this.uploadedOrderItemData[i][2] as number,
          this.uploadedOrderItemData[i][3] as number
        ));
      }
    }
    this.service.saveImportedOrderItems(data).subscribe(res => {
      this.getAllOrderItems();
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
      const wb: XLSX.WorkBook = XLSX.read(bstr, { type: 'binary' });

      /* grab first sheet */
      const wsname: string = wb.SheetNames[0];
      const ws: XLSX.WorkSheet = wb.Sheets[wsname];

      /* fill data */
      this.uploadedOrderItemData = (XLSX.utils.sheet_to_json(ws, { header: 1 }));
    }
    evt.target.value = null;
  }

}
