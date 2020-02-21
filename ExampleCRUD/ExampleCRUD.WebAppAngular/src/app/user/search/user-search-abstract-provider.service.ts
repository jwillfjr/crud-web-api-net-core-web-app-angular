import { User } from '../../models/user';

export abstract class UserSearchAbstractProvider {
    abstract searchUsers(nameOrDocument: string): Promise<User[]>;
    
    abstract save(user: User): Promise<User> ;
    abstract delete(userId: number): Promise<boolean> 
}