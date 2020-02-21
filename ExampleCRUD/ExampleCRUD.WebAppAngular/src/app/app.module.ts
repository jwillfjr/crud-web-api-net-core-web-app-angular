import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {
  MatAutocompleteModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatExpansionModule,
  MatFormFieldModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatMenuModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatSortModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
  MatStepperModule,
  MatRippleModule,
  MatNativeDateModule,
  MatTreeModule,
  MatBadgeModule,
  MatBottomSheetModule,
  MatDividerModule,
  MatCard,
  MatListModule,
  MatSidenav,
  MatTab,
  MAT_INPUT_VALUE_ACCESSOR,
} from '@angular/material';
import { AppComponent, DialogOverviewExampleDialog } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { UserSearchCarService } from './user/user-search-card.service';
import { UserSearchCardComponent } from './user/search/user-search-card.component';
import { UserCrudComponent } from './user/crud/user-crud.component';
import { NgxMaskModule, IConfig } from 'ngx-mask'

export const options: Partial<IConfig> | (() => Partial<IConfig>)={};

@NgModule({
  declarations: [
    AppComponent,
    UserSearchCardComponent,
    UserCrudComponent,DialogOverviewExampleDialog
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    MatDividerModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatDialogModule,
    NgxMaskModule.forRoot(options)


  ],
  entryComponents: [DialogOverviewExampleDialog],
  providers: [UserSearchCarService],
  bootstrap: [AppComponent]
})
export class AppModule { }
