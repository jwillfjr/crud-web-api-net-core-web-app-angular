import { Injectable } from '@angular/core';
import { UserSearchAbstractProvider } from './search/user-search-abstract-provider.service';
import { User } from '../models/user';
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";

import { map } from 'rxjs/operators';

@Injectable()
export class UserSearchCarService extends UserSearchAbstractProvider {
    baseApi = "http://localhost:5000/api/user/"
    constructor(private http: HttpClient) {
        super();
    }

    searchUsers(nameOrCpfCnpj: string): Promise<User[]> {
        let headers = new HttpHeaders();
        headers.append('Content-Type', 'application/json; charset=utf-8')

        return this.http.get<User[]>(this.baseApi + `getbynameorcpfcnpj?nameorcpfcnpj=%${nameOrCpfCnpj}%&page=0&resultsPerPage=100`, { headers }).toPromise();
    }

    save(user: User): Promise<User> {
        debugger
        let headers = new HttpHeaders();
        headers.append('Content-Type', 'application/json; charset=utf-8')

        if (user.id && user.id > 0) {
            return this.http.put<boolean>(this.baseApi, user, { headers })
                .pipe(map(m => {
                    
                    return m === true ? user : <User>{}
                }))
                .toPromise();
        } else {
            return this.http.post<User>(this.baseApi, user, { headers }).toPromise();
        }
    }
    delete(userId: number): Promise<boolean> {
        let headers = new HttpHeaders();
        headers.append('Content-Type', 'application/json; charset=utf-8')

        return this.http.delete<boolean>(this.baseApi + userId, { headers }).toPromise();
    }

}