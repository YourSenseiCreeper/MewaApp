export interface Link {
    id: number;
    url: string;
    name: string;
    description: string | null;
    expiryDate: Date | null;
    userId: string | null;
    thumbnailContent: string | null;
    thumbnailId: number | null;
}

export interface AddLink {
    url: string;
    name: string;
    description: string | null;
    expiryDate: Date | null;
    tags: number[];
    groups: number[];
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

export interface SuccessResult {
    success: boolean;
    message: string | null;
}

export interface TagDto {
    id: number;
    name: string;
    description: string | null;
}