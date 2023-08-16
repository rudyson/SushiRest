import style from "./search.module.scss"
import {useCallback, useRef, useState} from "react";
import debounce from 'lodash.debounce'

export const Search = ({setSearch}) => {
    const [value, setValue] = useState('')
    const inputRef = useRef()
    const onClickClear = () => {
        setSearch('')
        setValue('')
        inputRef.current?.focus()
    }

    const updateSearchValue = useCallback(
        debounce((str) => {
            setSearch(str)
        }, 350),
        []
    )
    const onChangeInput = (event) => {
        setValue(event.target.value)
        updateSearchValue(event.target.value)

    }
    return (
        <section className={style.wrapper}>
            <input
                ref={inputRef}
                value={value}
                onChange={onChangeInput}
                className={style.inputField} placeholder="Search"></input>
            <svg className={style.loupe} width="36" height="36" viewBox="0 0 36 36" fill="none"
                 xmlns="http://www.w3.org/2000/svg">
                <circle cx="17.25" cy="17.25" r="14.25" stroke="#2E2E2E" strokeOpacity="0.35" strokeWidth="1.5"/>
                <path d="M27.75 27.75L33 33" stroke="#2E2E2E" strokeOpacity="0.35" strokeWidth="1.5"
                      strokeLinecap="round"/>
            </svg>
            {value && (
                <svg onClick={onClickClear}
                    className={style.closeIcon} height="48" viewBox="0 0 48 48" width="48"
                     xmlns="http://www.w3.org/2000/svg">
                    <path
                        d="M38 12.83l-2.83-2.83-11.17 11.17-11.17-11.17-2.83 2.83 11.17 11.17-11.17 11.17 2.83 2.83 11.17-11.17 11.17 11.17 2.83-2.83-11.17-11.17z"/>
                    <path d="M0 0h48v48h-48z" fill="none"/>
                </svg>
            )}
        </section>
    )
}
