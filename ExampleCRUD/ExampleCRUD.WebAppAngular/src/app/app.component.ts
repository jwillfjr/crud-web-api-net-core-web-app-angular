import { Component, ViewChild, Inject } from '@angular/core';
import { User } from './models/user';
import { UserSearchCarService } from './user/user-search-card.service';
import { UserCrudComponent } from './user/crud/user-crud.component';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'test-source-frontend';

  users: User[] = [];

  @ViewChild(UserCrudComponent, { static: true }) userCrudComponent: UserCrudComponent;

  constructor(private userSearchService: UserSearchCarService,
    public dialog: MatDialog) {

  }

  loadUsers(usrs: User[]) {
    this.users = usrs;
  }

  editing: boolean = false;

  add() {
    this.editing = true;
    this.userCrudComponent.add();
  }

  edit(user) {
    this.editing = true;
    this.userCrudComponent.edit(user);
  }

  onCancel() {
    this.editing = false;
  }
  onSave(user) {
    debugger
    var exists = this.users.find(u => {
      return u.id == user.id;
    });

    if (!exists) {
      this.users.push(user);
    } else {
      Object.assign(exists, user);
    }
    this.editing = false;
  }

  remove(user) {
    const dialogRef = this.dialog.open(DialogOverviewExampleDialog, {
      width: '250px',
      data: user
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result === true) {
        this.userSearchService.delete(user.id).then(res => {
          debugger
          if (res === true) {
            this.users = this.users.filter((v) => {
              return v.id !== user.id;
            })
          }
        });
      }

    });
  }
}

@Component({
  selector: 'dialog-overview-example-dialog',
  template: `<h1 mat-dialog-title>Remove {{data.name}}</h1>
  <div mat-dialog-content>
    <p>Confirm action?</p>
  </div>
  <div mat-dialog-actions>
    <button mat-button (click)="onNoClick()">Cancel</button>
    <button mat-button [mat-dialog-close]="true" cdkFocusInitial>Ok</button>
  </div>`,
})
export class DialogOverviewExampleDialog {

  constructor(
    public dialogRef: MatDialogRef<DialogOverviewExampleDialog>,
    @Inject(MAT_DIALOG_DATA) public data: User) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
