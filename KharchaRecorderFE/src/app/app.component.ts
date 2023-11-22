import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Component } from '@angular/core';

import { ExpenseTypes } from './dto/expense-types';
import {ExpServiceService} from './services/exp-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {


  constructor(){
   console.log(GetUniqueFierstChar("aaaaaab"));
    function GetUniqueFierstChar(word:string) 
    {
      for(var i=0; i<word.length; i++)
      {
         var comp1 = word[i];
         for(var j =0; j < word.length ; j++)
         {
           let comp2 = word[j];
           var lastIndex = false;
           if(j == word.length -1)
           lastIndex = true;
           if(i == j && !lastIndex)
           continue;
           else if(comp1 == comp2 && !lastIndex)
           break;
           else if(lastIndex)
            return i + 1;
         }
      }
      return -1;
    }
  }
 
}
