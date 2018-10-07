import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material';
import { MatDividerModule } from '@angular/material';
import { MatFormFieldModule} from '@angular/material';
import { MatIconModule } from '@angular/material';

@NgModule({
    imports : [MatToolbarModule,
               MatDividerModule,
               MatFormFieldModule,
               MatIconModule],
    exports: [MatToolbarModule,
              MatDividerModule,
              MatFormFieldModule,
              MatIconModule]
})
export class MaterialModule {}
