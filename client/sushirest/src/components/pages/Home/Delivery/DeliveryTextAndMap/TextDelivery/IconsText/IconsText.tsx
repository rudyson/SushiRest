import style from "./IconsText.module.css";
import IconsDelivery from "./IconsDelivery/IconsDelivery";
import ContactToDelivery from "./ContactToDelivery/ContactToDelivery";

const IconsText = () => {
    return (
        <div className={style.wrapper}>
            <IconsDelivery/>
            <ContactToDelivery/>
        </div>
    );
}
export default IconsText;