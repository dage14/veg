import { ErrorHandler, Inject, Injectable, NgZone } from '@angular/core'; 
//import { ToastyService } from "ng2-toasty";

//@Injectable()
export class AppErrorHandler implements ErrorHandler
{
    constructor(
        //private ngZone: NgZone,
       // private toastyService: ToastyService
        ){

        }
       
    handleError(error: any): void {
        console.log(error);
      /* this.ngZone.run(() => {
            this.toastyService.error({
                title: 'Error',
                msg: 'An unexpected error happened.',
                theme: 'bootstrap',
                showClose: true,
                timeout: 5000
    
            });

       })*/
      

    }
    

}