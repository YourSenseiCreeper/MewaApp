export interface Link {
    id: number;
    url: string;
    name: string;
    description: string | null;
    expiryDate: Date | null;
    userId: number | null;
    //thumbnail: string | null; // byte[] powinno być
    thumbnailContent: string | null;
    thumbnailId: number | null;
}

export interface RegisterCommand {
    userName: string;
    email: string;
    password: string;
}

export interface RegisterCommandResult {
    success: boolean;
}

export interface LoginCommand {
    email: string;
    password: string;
}

export interface LoginCommandResult {
    message: string;
    success: boolean;
    token: string;
}