import { Component, OnInit } from '@angular/core';
import { Expense } from 'src/app/dto/expense';
import { ExpServiceService } from 'src/app/services/exp-service.service';

@Component({
  selector: 'app-add-expense',
  templateUrl: './add-expense.component.html',
  styleUrls: ['./add-expense.component.css']
})
export class AddExpenseComponent   {
  ExpTypes : any;
  Expenses : any;
  PayModes : any;
  expData = new Expense;
  lookupData = [
    { id: 2, name: 'Not Started' },
    { id: 2, name: 'Need Assistance' }
    // ...
];
  constructor(private expService : ExpServiceService) { 
    this.EditTRRecord = this.EditTRRecord.bind(this);
    this.expService.getExpTypes('Expense/GetListOfExpense').subscribe(data => {
      if(!data.error)
      {
        this.Expenses = data.obj;
      //  console.log(data.obj);
      }
    });
    //console.log(this.expService.getExpTypes());
    this.expService.getExpTypes('Expense/GetExpTypes').subscribe(data => {
      if(!data.error)
      {
        this.ExpTypes = data.obj;
     
      }
    });

    this.expService.getExpTypes('Expense/GetPaymentTypes').subscribe(data => {
      if(!data.error)
      {
        this.PayModes = data.obj;
      }
    });

    console.log(this.expService.getHackerRankData());
    //this.expService.getExpTypesTwo();
  }

  EditTRRecord(event: { row: any; }) {
    console.log('test');
}

onRowInserted(event: any) {
  this.expData = new  Expense;
  this.expData.Name = event.data.name;
  this.expData.PaymentModeId = event.data.paymentModeId;
  this.expData.ExpenseTypeId = event.data.expenseTypeId;
  this.expData.Amount = event.data.amount;
  console.log(this.expData);
  this.expService.PostPutDeleteExp("Expense/PostExpense",this.expData).subscribe(data => {
    if(!data.error)
    {
      this.refreshData();
    }
  });
}

onRowUpdated(event: any) {
  this.expData = new  Expense;
  this.expData.Id = event.data.id;
  this.expData.Name = event.data.name;
  this.expData.PaymentModeId = event.data.paymentModeId;
  this.expData.ExpenseTypeId = event.data.expenseTypeId;
  this.expData.Amount = event.data.amount;
  console.log(this.expData);
  this.expService.PostPutDeleteExp("Expense/PutExpense",this.expData).subscribe(data => {
    if(!data.error)
    {
      this.refreshData();
    }
  });
}

onRowRemoved(event: any) {
  this.expData = new  Expense;
  this.expData.Id = event.data.id;
  this.expData.Name = event.data.name;
  this.expData.PaymentModeId = event.data.paymentModeId;
  this.expData.ExpenseTypeId = event.data.expenseTypeId;
  this.expData.Amount = event.data.amount;
  console.log(this.expData);
  this.expService.PostPutDeleteExp("Expense/DeleteExpense",this.expData).subscribe(data => {
    if(!data.error)
    {
      this.refreshData();
    }
  });
}

refreshData()
{
  this.expService.getExpTypes('Expense/GetListOfExpense').subscribe(data => {
    if(!data.error)
    {
      this.Expenses = data.obj;
    //  console.log(data.obj);
    }
  });
}
}
