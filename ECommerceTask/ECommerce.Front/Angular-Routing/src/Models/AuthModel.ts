import { UserType } from '../emuns/UserType'; // Update with the correct path

export class AuthModel {
    username: string;
    token: string;
    userType: UserType;
    refreshToken: string;
    refreshTokenExpiration: Date;
    lastLoginTime: Date;
}
