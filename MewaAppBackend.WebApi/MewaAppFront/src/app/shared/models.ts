export interface Link {
    id: number;
    url: string;
    name: string;
    description: string | null;
    expiryDate: Date | null;
    userId: number | null;
    //thumbnail: string | null; // byte[] powinno być
    thumbnailId: number | null;
}