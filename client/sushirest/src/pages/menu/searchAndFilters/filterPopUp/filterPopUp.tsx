import style from "./filterPopUp.module.scss"
import {useEffect, useRef, useState} from "react";

export const FilterPopUp = ({categoryId, onChangeCategory}) => {
    const [open, setOpen] = useState(false)
    const filter = ['Filter','Salmon','Eel','Shrimp']
    const filterName = filter[categoryId]
    const filterRef = useRef()

    const onClickFilterItem = (id) => {
        onChangeCategory(id)
        setOpen(false)
    }

    useEffect(() => {
        const handleClickOutside = (event) => {
            if (!event.composedPath().includes(filterRef.current)){
                setOpen(false)
            }
        }

        document.body.addEventListener('click', handleClickOutside)

        return () => {
            document.body.removeEventListener('click', handleClickOutside)
        }

    }, [])

    return (
        <div ref = {filterRef} className={style.wrapper}>
            <section onClick={() => setOpen(!open)} className={open === true ? style.activeWrapperSec : style.wrapperSec}>
                <p>{filterName}</p>
                <svg width="18" height="13" viewBox="0 0 18 13" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <path d="M1 1L9 11L17 1" stroke="#2E2E2E" strokeWidth="2"/>
                </svg>
            </section>
            {open && (
                <ul className={style.options}>
                    {
                        filter.map((el, i) => (
                            <li onClick={() => onClickFilterItem(i)} key={i}>{el}</li>
                        ))
                    }
                </ul>
            )}
        </div>
    )
}
