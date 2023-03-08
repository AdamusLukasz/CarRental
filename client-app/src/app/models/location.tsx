import {Car} from './car';

export interface Location {
    id: number,
    name: string,
    cars: [
        Car
    ]
}