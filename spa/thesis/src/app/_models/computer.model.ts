import { GraphicsCard } from "./graphicsCard.model";
import { PowerSupply } from "./powerSupply.model";
import { Processor } from "./processor.model";
import { RAM } from "./ram.model";
import { USBPorts } from "./usbPorts.model";


export interface Computer {
    "graphicsCardId": string;
    "powerSupplyId": string;
    "processorId": string;
    "ramId": string;
    "storageId": string;
    "usbPortsId": string;
    "weightInGrams": number;
    "graphicsCard": GraphicsCard;
    "powerSupply": PowerSupply;
    "processor": Processor;
    "ram": RAM;
    "storage": Storage;
    "usbPorts": USBPorts;
    "id": string;
}