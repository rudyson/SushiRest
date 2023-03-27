import style from "./DeliveryTextMap.module.css";
import GoogleMap from "./Map/Map";
import TextDelivery from "./TextDelivery/TextDelivery";

const DeliveryTextMap = () => {
    return (
        <div className={style.wrapper}>
            <TextDelivery/>
            <GoogleMap/>
        </div>

    );
}
export default DeliveryTextMap;