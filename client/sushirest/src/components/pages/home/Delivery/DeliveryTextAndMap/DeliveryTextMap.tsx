import style from "./deliveryTextMap.module.scss";
import {Map, TextDelivery} from "../../../../../index.ts";

export const DeliveryTextMap = () => {
    return (
        <div className={style.wrapper}>
            <TextDelivery/>
            <Map/>
        </div>
    );
}
