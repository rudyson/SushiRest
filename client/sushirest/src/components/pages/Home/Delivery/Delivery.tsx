import style from "./Delivery.module.css";
import DeliveryTextMap from "./DeliveryTextAndMap/DeliveryTextMap";


const Delivery = () => {
    return (
        <div className={style.wrapper}>
            <h1 className={style.mainText}>delivery</h1>
            <DeliveryTextMap/>
        </div>

    );
}
export default Delivery;