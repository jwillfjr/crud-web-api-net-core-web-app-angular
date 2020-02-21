import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { UserSearchAbstractProvider } from './user-search-abstract-provider.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'user-search-card',
    templateUrl: './user-search-card.component.html',
    styleUrls: ['./user-search-card.component.css']
})
export class UserSearchCardComponent implements OnInit {

    @Input() userSearchAbstractProvider: UserSearchAbstractProvider;

    @Output() onPartnerSelectedEvent = new EventEmitter();
    @Output() onAddEvent = new EventEmitter();
    options: FormGroup;

    constructor(fb: FormBuilder) {
        this.options = fb.group({
            nameOrDocument: ''
        });
    }

    ngOnInit(): void { }

    search() {
        this.userSearchAbstractProvider.searchUsers(this.options.controls['nameOrDocument'].value)
            .then(users => {
                this.onPartnerSelectedEvent.emit(users);
            })
    }

    add(){
        this.onAddEvent.emit();
    }
}
