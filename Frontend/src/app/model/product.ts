import { Model } from "./model";

export interface Product {
    id?: number;
    name: string;
    description: string;
    imageURL: string;
    guid?: string;
    models?: Model[]
}