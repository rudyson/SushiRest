import style from "./footer.module.scss"
import {NavigateFooter, LeftFooter} from "../../../index.ts"

const Footer = () => {
    return (
        <footer className={style.wrapper}>
            <LeftFooter/>
            <NavigateFooter/>
            <p className={style.text}>© «SUSHIREST» </p>
            <p className={style.producedBy}>Designed by Eugene Shal</p>
        </footer>
    );
}

export default Footer;