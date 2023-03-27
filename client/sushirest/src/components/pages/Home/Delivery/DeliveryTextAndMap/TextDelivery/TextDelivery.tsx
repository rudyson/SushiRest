import style from "./TextDelivery.module.css";
import IconsText from "./IconsText/IconsText";


const TextDelivery = () => {
    return (
        <div className={style.wrapper}>
            <p className={style.text}>Come to us</p>
            <IconsText/>
        </div>

    );
}
export default TextDelivery;