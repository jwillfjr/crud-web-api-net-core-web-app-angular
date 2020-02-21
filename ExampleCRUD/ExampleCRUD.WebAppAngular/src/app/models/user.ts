export interface User {
    email: string;
    addressStreet: string;
    addressNumber: string;
    addressCity: string;
    addressState: string;
    addressZipCode: string;
    name: string;
    birthDate?: Date;
    cpfCnpj: string;
    id: number;
    actived: boolean;
    created: Date;
}

export class User implements User{
    constructor(){
        this.id = 0;
        this.created = new Date();
        this.actived = true;
        this.email = '';
        this.addressStreet = '';
        this.addressNumber = '';
        this.addressCity = '';
        this.addressState = '';
        this.addressZipCode = '';
        this.name = '';
    }
}