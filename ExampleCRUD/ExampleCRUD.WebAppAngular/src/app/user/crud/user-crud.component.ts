import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserSearchAbstractProvider } from '../search/user-search-abstract-provider.service';
import { User } from 'src/app/models/user';

@Component({
    selector: 'user-crud',
    templateUrl: './user-crud.component.html',
    styleUrls: ['./user-crud.component.css']
})
export class UserCrudComponent implements OnInit {

    userForm: FormGroup;
    @Input() userSearchAbstractProvider: UserSearchAbstractProvider;

    @Output() onSaveEvent = new EventEmitter();
    @Output() onCancelEvent = new EventEmitter();

    constructor(fb: FormBuilder) {
        this.userForm = fb.group({
            id: 0,
            email: ['', [Validators.required, Validators.email]],
            addressStreet: ['', Validators.required],
            addressNumber: ['', Validators.required],
            addressCity: ['', Validators.required],
            addressState: ['', Validators.required],
            addressZipCode: ['', Validators.required],
            name: ['', Validators.required],
            birthDate: [null, Validators.required],
            cpfCnpj: ['', Validators.required],
            actived: true,
            created: new Date()
        });
    }

    ngOnInit(): void { }

    get enableSubmit() {
        // return this.formGruopSubject.getValue() &&
        //     !this.formGruopSubject.getValue().pristine &&
        //     !this.formGruopSubject.getValue().invalid;
        return this.userForm &&
            !this.userForm.pristine &&
            !this.userForm.invalid;
    }

    add() {        
        this.userForm.reset(new User);
        
    }

    edit(user: User) {
        let userData = {};
        for (const key of Object.keys(this.userForm.controls)) {
            userData[key] = user[key];
        }
        this.userForm.setValue(userData);
    }

    save() {
        this.userSearchAbstractProvider.save(this.userForm.value as User)
            .then(user => {
                this.onSaveEvent.emit(user);
                this.userForm.reset();
            })
    }
    cancel() {
        this.userForm.reset();
        this.onCancelEvent.emit();
    }
}
