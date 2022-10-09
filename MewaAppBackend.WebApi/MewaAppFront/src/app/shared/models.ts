export interface Link {
    id: number;
    url: string;
    name: string;
    description: string | null;
    expiryDate: Date | null;
    isPublic: boolean;
    ownerId: string | null;
    thumbnailContent: string | null;
    thumbnailId: number | null;
    tags: MicroTag[];
    groups: MicroGroup[];
}

export interface MicroLink {
    id: number;
    name: string;
    url: string;
}

export interface MicroTag {
    id: number;
    name: string;
}

export interface MicroGroup {
    id: number;
    name: string;
}

export interface AddLinkToGroup {
    url: string;
    name: string;
    description: string | null;
    expiryDate: Date | null;
    groupId: number;
}

export interface AddGroup {
    redirectUrl: string,
    name: string,
    description: string,
    isFolder: boolean,
    links: number[],
    tags: number[],
    users: string[]
}


export interface MewaElementDto {
    id: number,
    name: string,
    isFolder: boolean,
    url: string,
}

export interface GroupDto {
    id: number,
    name: string,
    elements: MewaElementDto[]
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

export interface TokenDTO {
    token: string
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