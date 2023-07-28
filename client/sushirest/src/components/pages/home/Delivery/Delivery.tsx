import style from "./delivery.module.scss";
import {DeliveryTextMap} from "../../../../index.ts";

export const Delivery = () => {
    return (
        <div className={style.wrapper}>
            <h1>delivery</h1>
            <DeliveryTextMap/>
        </div>
    );
}
