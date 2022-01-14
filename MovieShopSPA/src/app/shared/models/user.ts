export interface User {
    maneid: number;
    family_name: string;
    given_name: string;
    email: string;
    role: Array<string>;
    exp: string;
    alias: string;
    isAdmin: boolean;
    birthdate: Date;
}