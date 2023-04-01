import style from "./Footer.module.css"
import LeftFooter from "./LeftFooter/LeftFooter";
import NavigateFooter from "./NavigateFooter/NavigateFooter";

const Footer = () => {
    return (
        <div className={style.wrapper}>
            <LeftFooter/>
            <NavigateFooter/>
            <p className={style.text}>© «SUSHIREST» </p>
            <p className={`${style.text} ${style.producedBy}`}>Designed by Eugene Shal</p>
        </div>
    );
}

export default Footer;