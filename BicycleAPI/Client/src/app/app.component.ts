import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Bicycle } from './bicycle';
import { BicycleType } from './bicycle.type';

@Component({
    selector: 'app',
    templateUrl: '../app.component.html',
    providers: [DataService]
})

export class AppComponent implements OnInit {
   bicycle: Bicycle = new Bicycle();
   bicycles: Bicycle[];
   bicycleTypes: BicycleType[];
   totalPrice: number;
   availableBicyclesCount: number;

   constructor(private dataService: DataService) { }

   ngOnInit() {
       this.loadBicycleTypes();
       this.loadBicycles();
   }

   loadBicycles() {
       this.dataService.getBicycles()
           .subscribe((data: Bicycle[]) => { this.bicycles = data; this.getStats(data)});
   }

   loadBicycleTypes() {
       this.dataService.getBicycleTypes()
           .subscribe((data: BicycleType[]) => this.bicycleTypes = data);
   }

    create() {
        this.bicycle.bicycleTypeId = +this.bicycle.bicycleTypeId;
        this.bicycle.isRented = false;
        this.dataService.createBicycle(this.bicycle)
           .subscribe((data: Bicycle) => this.bicycles.push(data));
    }

    getBicycleTypeName(b: Bicycle) {
        return this.bicycleTypes.find(item => item.id == b.bicycleTypeId).name;
    }

    edit(b: Bicycle) {
        b.isRented = !b.isRented;
        this.dataService.editBicycle(b)
            .subscribe(data => this.loadBicycles());
    }

    delete(b: Bicycle) {
        this.dataService.deleteBicycle(b.id)
           .subscribe(data => this.loadBicycles());
    }

    getStats(b: Bicycle[]) {
        this.totalPrice = 0;
        this.availableBicyclesCount = 0;
        b.forEach(el => {
            this.totalPrice += el.isRented ? el.price : 0;
            this.availableBicyclesCount += !el.isRented ? 1 : 0;
        });
    }
}